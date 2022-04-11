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

    public IEnumerable<Component>  componentEnumerable { get; set; }

    private IComponentRepository _componentRepo;

    public dataStorageModel(ILogger<dataStorageModel> logger,
		    IComponentRepository componentRepo)
    {
        _logger = logger;
	_componentRepo = componentRepo;
	componentEnumerable = _componentRepo.getAllComponents();
    }

    public void OnGet()
    {

    }
    
    public void OnPostPopulate(){

	    _componentRepo.populateComponents();
	    componentEnumerable = _componentRepo.getAllComponents();

    }

    public void OnPostClearAll(){

	    _componentRepo.clearAllComponents();
	    componentEnumerable = _componentRepo.getAllComponents();
    }

    public void OnPostAddComponent(){


	    if(ModelState.IsValid){

		    Component newComponent = new Component();

		    newComponent.name = this.name;
		    newComponent.componentType = this.componentType;
		    newComponent.temperatureC = this.temperatureC;
		    newComponent.pressurePa = this.pressurePa;
		    newComponent.massFlowrateKgPerS = this.massFlowrateKgPerS;
		    newComponent.componentState = this.componentState;

		    _componentRepo.createComponent(newComponent);
	    }
    }

    public void OnPostDeleteComponent(){

	    _componentRepo.deleteComponent(this.Id);
    }

    public void OnPostUpdateComponent(){

	    if(this.Id != null){

		    if(ModelState.IsValid){

			    Component newComponent = new Component();

			    newComponent.Id = this.Id;
			    newComponent.name = this.name;
			    newComponent.componentType = this.componentType;
			    newComponent.temperatureC = this.temperatureC;
			    newComponent.pressurePa = this.pressurePa;
			    newComponent.massFlowrateKgPerS = this.massFlowrateKgPerS;
			    newComponent.componentState = this.componentState;

			    _componentRepo.updateComponent(Id,newComponent);
		    }
	    }
    }
	

    // here are the models for model binding
    //

    [BindProperty]
    public int Id { get; set; }

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

    [BindProperty]
    public bool componentState { get; set; }
}
