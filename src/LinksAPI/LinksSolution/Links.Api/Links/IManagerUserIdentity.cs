
namespace Links.Api.Links;

public interface IManagerUserIdentity
{
    Task<string> GetSubjectAsync();
}