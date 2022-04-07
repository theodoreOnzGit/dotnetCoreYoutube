using Microsoft.AspNetCore.Mvc;

namespace dotnetTest.Models;

public interface IComponentCollection
{
	 
	List<Component> list { get; set; }

	void populateList();
	void clearList();

	Component getPipe1();
	Component getPump1();
	Component getHeatExchanger1();
}


public class ComponentList : IComponentCollection
{

	public List<Component> list { get; set; }

	public ComponentList(){

		list = new List<Component>();

	}

	public void populateList(){

		Component pipe1 = getPipe1();

		list.Add(pipe1);

		Component pump1 = getPump1();

		list.Add(pump1);

		Component heatExchanger1 = getHeatExchanger1();

		list.Add(heatExchanger1);

		

	}

	public void clearList(){

		list.Clear();
	}

	public Component getPipe1(){

		Component pipe1 = new Component();

		pipe1.Id = 1;
		pipe1.name = "myPipe";
		pipe1.componentType = "pipe";
		pipe1.temperatureC = 25;
		pipe1.pressurePa = 101325;
		pipe1.massFlowrateKgPerS = 0.5;


		return pipe1;
	
	}

	public Component getPump1(){

		Component pump1 = new Component();

		pump1.Id = 2;
		pump1.name = "myPump";
		pump1.componentType = "pump";
		pump1.temperatureC = 25;
		pump1.pressurePa = 101325;
		pump1.massFlowrateKgPerS = 0.5;


		return pump1;
	
	}
	public Component getHeatExchanger1(){

		Component heatExchanger1 = new Component();

		heatExchanger1.Id = 3;
		heatExchanger1.name = "myHeatExchanger";
		heatExchanger1.componentType = "heatExchanger";
		heatExchanger1.temperatureC = 25;
		heatExchanger1.pressurePa = 101325;
		heatExchanger1.massFlowrateKgPerS = 0.5;


		return heatExchanger1;
	
	}
	
}
