export function enumToDropdown<T extends object>(enumType: T): string[] {
    return Object.keys(enumType)
      .filter(key => isNaN(Number(key)));
}