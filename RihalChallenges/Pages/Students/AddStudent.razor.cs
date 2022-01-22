using Common.Models;

namespace RihalChallenges.Pages.Students
{
    public class AddStudentBase: PageBase
    {

        protected StudentDTO model = new StudentDTO();

        protected List<ClassDTO> Classes = new();
        protected List<CountryDTO> Countries = new();

        protected override async Task OnInitializedAsync()
        {
            Classes = (await classService.GetAll()).ToList();
            Countries = (await countryService.GetAll()).ToList();

            if (Classes.Count > 0)
            {
                model.ClassId = Classes[0].Id;
            }

            if (Countries.Count > 0)
            {
                model.CountryId = Countries[0].Id;
            }
        }

        protected async Task Submit()
        {
            await form.Validate();

            if (form.IsValid)
            {
                var isCreated = await studentService.Create(model);

                if (isCreated)
                {
                    Snackbar.Add("Submited!");
                    Thread.Sleep(500);
                    NavigationManager.NavigateTo("students");
                }
                else
                {
                    Snackbar.Add("Error!");
                }

            }
        }

    }
}
