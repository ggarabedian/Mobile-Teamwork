namespace PersonalOrganiser.ViewModels.Contracts
{
    public interface IPageViewModel
    {
        string Title { get; }

        IContentViewModel ContentViewModel { get; set; }
    }
}
