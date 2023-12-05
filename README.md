# DotNet Core API Testing Utils

This Repo consists of the following helper methods to test the APIs built using .net core: 
    
    1. ApiHelper.PostJsonApiRequest
    2. ApiHelper.PostXmlApiRequest
    3. ApiHelper.GetApiRequest      


ApiHelper.PostJsonApiRequest:

    This method is used to make an asynchronous POST API call with JSON request parameterized with url, request body and headers[optional].
    It returns the HttpResponse.
    
ApiHelper.PostXmlApiRequest:

    This method is used to make an asynchronous POST API call with XML request parameterized with url, request body and headers[optional].
    It returns the HttpResponse.
ApiHelper.GetApiRequest:

    This method is used to make an asynchronous GET API request parameterized with url and headers [optional].
    It returns the HttpResponse.

## Install Package from Quget Gallery [TODO]

Package Source
      
    https://qugetgal.rockfin.com/api/v2

Installation Steps   

    1. [Todo]
## Usage Code Snippets

Post JSON:

    var httpResponse = await ApiHelper.PostJsonApiRequest(url, testData.ToJson(),headers[optional]);
Post XML:
 
    var httpResponse = await ApiHelper.PostXmlApiRequest(url, testData.ToXml(),headers[optional]);
    
Get API:

    var httpResponse = await ApiHelper.GetApiRequest(url, headers[optional]);
Here is the  [GIT Repo](https://git.rockfin.com/QAPOW/QAPOW_CSharpApiUtils_DotNetCore).


