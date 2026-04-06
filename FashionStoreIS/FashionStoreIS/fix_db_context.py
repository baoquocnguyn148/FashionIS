
import os
import re

filepath = r'd:\FashionStoreIS\FashionStoreIS\FashionStoreIS\Data\ApplicationDbContext.cs'
with open(filepath, 'r', encoding='utf-8') as f:
    content = f.read()

# Fix the Identity ones if they match the original pattern
# Pattern 1: entity.Property(e => e.Id).HasColumnName("ID").UseHiLo("HILOSEQUENCE")
# Pattern 2: b.Property(e => e.Id).UseHiLo("HILOSEQUENCE").HasColumnName("ID")

# I've already fixed some, so I'll just use a more general regex to find .UseHiLo inside if(isOracle)
# or just look for lines containing UseHiLo that aren't already qualified.

def fix_line(match):
    full_line = match.group(0)
    if "OraclePropertyBuilderExtensions.UseHiLo" in full_line:
        return full_line
    
    # Example format: b.Property(e => e.Id).UseHiLo("HILOSEQUENCE").HasColumnName("ID")
    # or: entity.Property(e => e.Id).HasColumnName("ID").UseHiLo("HILOSEQUENCE")
    
    m = re.search(r'([^\s]+)\.Property\(.*?\)\.UseHiLo\(.*?\)', full_line)
    if m:
        # Extract the property builder part
        # We want to transform: (builder part).UseHiLo("HILOSEQUENCE")
        # To: OraclePropertyBuilderExtensions.UseHiLo((builder part), "HILOSEQUENCE")
        
        inner_m = re.search(r'(.*?)\.UseHiLo\("(.*?)"\)', full_line)
        if inner_m:
            prefix = inner_m.group(1)
            sequence = inner_m.group(2)
            # Find where the property builder starts on that line
            # It usually starts after the 'if (isOracle)'
            if 'if (isOracle)' in prefix:
                parts = prefix.split('if (isOracle)')
                return f"{parts[0]}if (isOracle) OraclePropertyBuilderExtensions.UseHiLo({parts[1].strip()}, \"{sequence}\");"
    
    return full_line

# Much simpler: just replace specific problematic patterns
new_content = content.replace('.UseHiLo("HILOSEQUENCE")', '') # This is too risky

# Better:
patterns_to_replace = [
    ('if (isOracle) b.Property(e => e.Id).UseHiLo("HILOSEQUENCE").HasColumnName("ID");', 
     'if (isOracle) OraclePropertyBuilderExtensions.UseHiLo(b.Property(e => e.Id).HasColumnName("ID"), "HILOSEQUENCE");'),
    ('b.Property(e => e.Id).UseHiLo("HILOSEQUENCE").HasColumnName("ID");',
     'OraclePropertyBuilderExtensions.UseHiLo(b.Property(e => e.Id).HasColumnName("ID"), "HILOSEQUENCE");')
]

for old, new in patterns_to_replace:
    content = content.replace(old, new)

with open(filepath, 'w', encoding='utf-8') as f:
    f.write(content)

print("Done fixing ApplicationDbContext.cs")
