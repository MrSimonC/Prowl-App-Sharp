#!/usr/bin/env python3
import re
import sys


def main() -> int:
    version_string = sys.argv[1] if len(sys.argv) > 1 else ""
    match = re.search(r"(?P<major>\d+)(\.(?P<minor>\d+))?(\.(?P<patch>\d+))?(\-(?P<pre>[0-9A-Za-z\-.]+))?(\+(?P<build>\d+))?", version_string)

    if match is None:
        print("1.0.0-build")
        return 0

    major = int(match.group("major") or 0)
    minor = int(match.group("minor") or 0)
    patch = int(match.group("patch") or 0)
    prerelease = match.group("pre") or ""
    build = int(match.group("build") or 0)

    version = f"{major}.{minor}.{patch}"
    if prerelease:
        version += f"-{prerelease}"
    if build != 0:
        version += f".{build}"

    print(version)
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
