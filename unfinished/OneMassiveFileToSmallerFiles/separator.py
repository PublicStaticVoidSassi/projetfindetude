# this was written by chatgpt
from pathlib import Path


input_file = Path("large.txt")
output_dir = Path("segments")

output_dir.mkdir(exist_ok=True)

with input_file.open("r", encoding="utf-8") as f:
    content = f.read()

segments = content.split("================")

for i, segment in enumerate(segments, start=1):
    segment = segment.strip()

    if not segment:
        continue

    output_file = output_dir / f"segment_{i}.txt"

    with output_file.open("w", encoding="utf-8") as f:
        f.write(segment)

print(f"Created {len(segments)} segments in {output_dir}/")
