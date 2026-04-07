$(function () {
    const csrfToken = $('meta[name="csrf-token"]').attr('content');
    if (csrfToken) {
        $.ajaxSetup({
            headers: { 'RequestVerificationToken': csrfToken }
        });
    }

    const $drawerOverlay = $('#drawerOverlay');
    const $body = $('body');

    const $navDrawer = $('#navDrawer');
    const $hamburgerBtn = $('#hamburgerBtn');
    const $closeDrawerBtn = $('#closeDrawerBtn');

    function anyDrawerOpen() {
        return $navDrawer.hasClass('open') || $('#cartDrawer').hasClass('open');
    }

    function ensureOverlayState() {
        if (anyDrawerOpen()) $drawerOverlay.addClass('active');
        else $drawerOverlay.removeClass('active');

        if (anyDrawerOpen()) $body.addClass('drawer-open');
        else $body.removeClass('drawer-open');
    }

    function openNavDrawer() {
        $navDrawer.addClass('open');
        ensureOverlayState();
    }

    function closeNavDrawer() {
        $navDrawer.removeClass('open');
        ensureOverlayState();
    }

    $hamburgerBtn.on('click', function () {
        if ($navDrawer.hasClass('open')) closeNavDrawer();
        else openNavDrawer();
    });

    $closeDrawerBtn.on('click', closeNavDrawer);

    $drawerOverlay.on('click', function () {
        if (window.closeCart) window.closeCart();
        closeNavDrawer();
    });

    $(document).on('click', '.filter-title', function () {
        $(this).closest('.filter-group').toggleClass('collapsed');
    });

    // ─── Header Search Logic ───────────────────────
    function executeSearch() {
        const query = $('#headerSearchInput').val();
        if (query !== undefined && query.trim() !== "") {
            window.location.href = '/Product/List?q=' + encodeURIComponent(query);
        }
    }
    
    (function syncHeaderSearchInput() {
        const $input = $('#headerSearchInput');
        if ($input.length === 0) return;
        const urlParams = new URLSearchParams(window.location.search);
        const q = urlParams.get('q');
        if (q) $input.val(q);
    })();

    $('#headerSearchInput').on('keypress', function (e) {
        if (e.which === 13) {
            executeSearch();
        }
    });

    $('#headerSearchBtn').on('click', function () {
        const $input = $('#headerSearchInput');
        if ($input.val() && $input.val().trim() !== "") {
            executeSearch();
        } else {
            $input.focus();
        }
    });

    // ─── Cart Drawer Logic ───────────────────────
    const $cartDrawer = $('#cartDrawer');

    window.openCart = function () {
        if ($cartDrawer.length === 0) {
            window.location.href = '/Cart/Index';
            return;
        }
        closeNavDrawer();
        $cartDrawer.addClass('open');
        ensureOverlayState();
        loadCartDrawer();
    }

    window.closeCart = function () {
        $cartDrawer.removeClass('open');
        ensureOverlayState();
    }

    $('#openCart').on('click', function (e) {
        // If cart drawer exists, use it; otherwise fall back to /Cart/Index navigation.
        if ($cartDrawer.length > 0) {
            e.preventDefault();
            openCart();
        }
    });
    $(document).on('click', '#closeCart', closeCart);

    function loadCartDrawer() {
        $('#cartContent').load('/Cart/GetCartDrawer', function() {
            refreshCartCount();
        });
    }

    window.updateCartQty = function (productId, color, size, delta) {
        $.post('/Cart/UpdateQuantity', { productId, color, size, delta }, function (html) {
            $('#cartContent').html(html);
            refreshCartCount();
        });
    }

    window.removeFromCart = function (productId, color, size) {
        $.post('/Cart/RemoveFromCart', { productId, color, size }, function (html) {
            $('#cartContent').html(html);
            refreshCartCount();
        });
    }

    $(document).on('click', '.qty-btn', function () {
        const $btn = $(this);
        const productId = parseInt($btn.data('product-id'), 10);
        const color = $btn.data('color') ?? '';
        const size = $btn.data('size') ?? '';
        const delta = parseInt($btn.data('delta'), 10);
        if (!Number.isFinite(productId) || !Number.isFinite(delta)) return;
        window.updateCartQty(productId, color, size, delta);
    });

    $(document).on('click', '.remove-btn', function () {
        const $btn = $(this);
        const productId = parseInt($btn.data('product-id'), 10);
        const color = $btn.data('color') ?? '';
        const size = $btn.data('size') ?? '';
        if (!Number.isFinite(productId)) return;
        window.removeFromCart(productId, color, size);
    });

    function refreshCartCount() {
        $.get('/Cart/GetCartCount', function(res) {
            const count = res.count || 0;
            const $badge = $('#cartBadge');
            $badge.text(count);
            if (count > 0) $badge.show(); else $badge.hide();
        });
    }

    // Initial load
    refreshCartCount();
});
