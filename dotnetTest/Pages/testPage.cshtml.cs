using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dotnetTest.Models;

// this namespace is for validation of forms
using System.ComponentModel.DataAnnotations;



namespace dotnetTest.Pages;

public class testPageModel : PageModel
{
    private readonly ILogger<testPageModel> _logger;

	private readonly IMath _math;

    public testPageModel(ILogger<testPageModel> logger,
			IMath math)
    {
        _logger = logger;
		this._math = math;
    }

    public void OnGet()
    {

    }

	[BindProperty]
	[Required]
	public double numberToAdd { get; set; }

	public double numberResult { get; set; }


	public void OnPostAdd(){

		if(ModelState.IsValid){
			this.numberResult = this._math.addition(this.numberToAdd);
		}
	}
}
