using Common.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Persistence.Services;
using RihalChallenges.Validators;

namespace RihalChallenges.Pages.Class
{
    public class AddClassBase: PageBase
    {
        protected MudForm form = new MudForm();

        protected ClassDTO model = new ClassDTO();
        protected ClassValidator classValidator = new ClassValidator();

        protected async Task Submit()
        {
            await form.Validate();

            if (form.IsValid)
            {
                var isCreated = await classService.Create(model);

                if (isCreated)
                {
                    Snackbar.Add("Submited!");
                    NavigationManager.NavigateTo("classes");
                }
                else
                {
                    Snackbar.Add("Error!");
                }
            }
        }
    }
}
