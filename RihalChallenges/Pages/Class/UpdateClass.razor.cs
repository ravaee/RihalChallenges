using Common.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace RihalChallenges.Pages.Class
{
    public class UpdateClassBase: PageBase
    {

        protected ClassDTO model = new ClassDTO();

        [Parameter]
        public string Id { get; set; }


        protected override async Task OnInitializedAsync()
        {
            if (Id == null)
            {
                return;
            }

            model = await classService.Get(int.Parse(Id));
        }

        protected async Task Submit()
        {
            await form.Validate();

            if (form.IsValid)
            {

                var isUpdated = await classService.Update(model);

                if (isUpdated)
                {
                    Snackbar.Add("Class Has Been Updated!");
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
