using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// dotnetTest Models namespace for dataStorage 

using dotnetTest.Models;

// this namespace is for validation of forms

using System.ComponentModel.DataAnnotations;

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

    public void OnPostAddComponent(){

	    if(ModelState.IsValid){

	    Component newComponent = new Component();

	    newComponent.Id = 1;
	    newComponent.name = name;
	    newComponent.componentType = componentType;
	    newComponent.temperatureC = temperatureC;
	    newComponent.pressurePa = pressurePa;
	    newComponent.massFlowrateKgPerS = massFlowrateKgPerS;

	    _componentCollection.list.Add(newComponent);
	    }

    }

    // here are the models for model binding
    //

    [BindProperty]
    [Required]
    public string name { get; set; }

    [BindProperty]
    [Required]
    public string componentType { get; set; }

    [BindProperty]
    [Required]
    public double temperatureC { get; set; }

    [BindProperty]
    [Required]
    public double pressurePa { get; set; }

    [BindProperty]
    [Required]
    public double massFlowrateKgPerS { get; set; }
}
