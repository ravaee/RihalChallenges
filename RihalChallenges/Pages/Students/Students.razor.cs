namespace RihalChallenges.Pages.Students
{
    public class Studentsbase: PageBase
    {


        protected List<Common.Models.StudentDTO>? _Students;

        protected async Task OnDeleteClickedHandler(int studentId)
        {

            var result = await studentService.Remove(studentId);

            if (result)
            {
                Snackbar.Add($"The Student with Studentd Id: {studentId.ToString()} has been removed");

                _Students = (await Task.Run(() => studentService.GetAll())).ToList();

                StateHasChanged();
            }
            else
            {
                Snackbar.Add("Error Happend");
            }
        }

        protected async Task OnUpdateClickedHandler(int studentId)
        {
            NavigationManager.NavigateTo($"student/update/{studentId}");
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _Students = (await Task.Run(() => studentService.GetAll())).ToList();
                StateHasChanged();
            }

        }
    }
}
