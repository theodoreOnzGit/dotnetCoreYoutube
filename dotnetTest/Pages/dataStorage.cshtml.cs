using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// dotnetTest Models namespace for dataStorage 

using dotnetTest.Models;

namespace dotnetTest.Pages;

public class dataStorageModel : PageModel
{
    private readonly ILogger<dataStorageModel> _logger;

    public IComponentCollection _componentCollection;

    public dataStorageModel(ILogger<dataStorageModel> logger,
		    IComponentCollection componentCollection)
    {
        _logger = logger;
	_componentCollection = componentCollection;
    }

    public void OnGet()
    {

    }
    
    public void OnPostPopulate(){

	    _componentCollection.populateList();
    }

    public void OnPostClearAll(){

	    _componentCollection.clearList();
    }
}
