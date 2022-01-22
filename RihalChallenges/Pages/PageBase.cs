using Microsoft.AspNetCore.Components;
using MudBlazor;
using Persistence.Services;
using RihalChallenges.Validators;

namespace RihalChallenges.Pages
{
    public abstract class PageBase: ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        //validators
        public ClassValidator classValidator = new ClassValidator();
        public StudentValidator studentValidator = new StudentValidator();

        //services 

        [Inject]
        public ClassService classService { get; set; }
        [Inject]
        public CountryService countryService { get; set; }
        [Inject]
        public StudentService studentService { get; set; }

        //form
        public MudForm form;
    }
}
