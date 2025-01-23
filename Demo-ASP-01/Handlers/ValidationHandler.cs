using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Demo_ASP_01.Handlers
{
    public static class ValidationHandler
    {
        public static void Required(this ModelStateDictionary modelState, object? value, string name)
        {
            if (string.IsNullOrWhiteSpace(value?.ToString()))
            {
                modelState.AddModelError(name, $"Le champ '{name}' est requis.");
            }
        }

        public static void MinLenght(this ModelStateDictionary modelState, string value, string name, int minChar = 1)
        {
            if(value is not null && value.Length < minChar)
            {
                modelState.AddModelError(name, $"Le champ '{name}' doit avoir au minimum {minChar} caractère(s).");
            }
        }

        public static void MaxLenght(this ModelStateDictionary modelState, string value, string name, int maxChar)
        {
            if (value is not null && value.Length > maxChar)
            {
                modelState.AddModelError(name, $"Le champ '{name}' doit avoir au maximum {maxChar} caractère(s).");
            }
        }
    }
}
