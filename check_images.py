import urllib.request, re
html = urllib.request.urlopen('https://fashion-store-web.onrender.com/Product/List').read().decode('utf-8')
matches = re.findall(r'<img[^>]+src=""([^""]+)""', html)
print(matches[:10])
