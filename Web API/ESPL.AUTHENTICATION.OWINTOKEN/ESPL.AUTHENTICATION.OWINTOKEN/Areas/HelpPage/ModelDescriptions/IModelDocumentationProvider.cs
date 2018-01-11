using System;
using System.Reflection;

namespace ESPL.AUTHENTICATION.OWINTOKEN.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}