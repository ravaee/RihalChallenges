namespace RihalChallenges.Pages.Class
{
    public class ClassesBase: PageBase
    {
        protected List<Common.Models.ClassDTO>? _Classes;

        protected async Task OnDeleteClickedHandler(int classId)
        {

            var result = await classService.Remove(classId);

            if (result)
            {
                Snackbar.Add(classId.ToString());

                _Classes = (await Task.Run(() => classService.GetAllWithStudents())).ToList();

                StateHasChanged();
            }
            else
            {
                Snackbar.Add("Error Happend");
            }
        }

        protected async Task OnUpdateClickedHandler(int classId)
        {
            NavigationManager.NavigateTo($"class/update/{classId}");
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _Classes = (await Task.Run(() => classService.GetAllWithStudents())).ToList();
                StateHasChanged();
            }
        }
    }
}
