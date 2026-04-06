
import os

filepath = r'd:\FashionStoreIS\FashionStoreIS\FashionStoreIS\Data\ApplicationDbContext.cs'
with open(filepath, 'r', encoding='utf-8') as f:
    lines = f.readlines()

for i in range(460, 485):
    if i < len(lines):
        print(f"{i+1}: {repr(lines[i])}")
