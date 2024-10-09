namespace AspireApp.ServiceDefaults.Models;

public record Click
{
    public Click(string userClick, string bottonName)
    {
        UserClick = userClick;
        BottonName = bottonName;
    }

    public string UserClick {  get; init; }
    public string BottonName { get; init; }
}
