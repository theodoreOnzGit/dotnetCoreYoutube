To make this compatible with dotnet core 6.0 and dotnet standard2.0 libs

I removed the vbproj files, config files, my Project files from the DWSim math operations

the following files were also removed:
/DWSIM.Math/BilinearInterpolation.vb
/DWSIM.Math/Intersection.vb

because both these solvers need to inherit a dwsim drawing class
those are exclusively for windows forms

the following vb file

IPOPTSolver.vb
was removed due to the IpoptAlgorithmMode interface being unavailable


the
LibOptimizationWrappers/ObjectiveFunction.vb

has a dependency:
LibOptimization.Optimization.absObjectiveFunction

it can be installed using:
https://www.nuget.org/packages/LibOptimization/
dotnet add package LibOptimization --version 1.13.0

the file
DWSIM.Math/Extrapolation.vb
relies on
Imports DWSIM.MathOps.MathEx
but it doesn't have the dependencies available, and so it was removed


DWSIM.Math/GDEM.vb
was removed because of an unresolveable dependency DWSIM.MathOps.MathEx
in mappack


LM.vb, LMFit.vb was removed as it uses too many VBA codes eg. UBound
DWSIM.Math/SysLin.vb was also removed because it contained vba codes
eg. FileClose, MsgBox etc. these are windows specific


DWSIM.Math/cMatLib.vb also uses too many VBA and windows specific commands
such as Err to be considered useful

General.vb, MatrixOps.vb and LP_Solve.vp were all removed as well for similar reasons

DWSIM.Math/NewtonSolver.vb(226,20): error BC30451: 'Common' is not declared.

Only after removal of these files, we arrived at a build able to use these
libraries...


AP.vb was modified so as to use If instead of IIf
idk if the syntax is okay. so it may be buggy


full list of deleted files:
	modified:   DWSIM.Math/AP.vb
	deleted:    DWSIM.Math/BilinearInterpolation.vb
	deleted:    DWSIM.Math/DWSIM.MathOps.vbproj
	deleted:    DWSIM.Math/Extrapolation.vb
	deleted:    DWSIM.Math/GDEM.vb
	deleted:    DWSIM.Math/General.vb
	deleted:    DWSIM.Math/IPOPTSolver.vb
	deleted:    DWSIM.Math/Intersection.vb
	deleted:    DWSIM.Math/LM.vb
	deleted:    DWSIM.Math/LMFit.vb
	deleted:    DWSIM.Math/LP_Solve.vb
	deleted:    DWSIM.Math/MatrixOps.vb
	deleted:    DWSIM.Math/My Project/Application.Designer.vb
	deleted:    DWSIM.Math/My Project/Application.myapp
	deleted:    DWSIM.Math/My Project/AssemblyInfo.vb
	deleted:    DWSIM.Math/My Project/Resources.Designer.vb
	deleted:    DWSIM.Math/My Project/Resources.resx
	deleted:    DWSIM.Math/My Project/Settings.Designer.vb
	deleted:    DWSIM.Math/My Project/Settings.settings
	deleted:    DWSIM.Math/NewtonSolver.vb
	deleted:    DWSIM.Math/SysLin.vb
	deleted:    DWSIM.Math/cMatLib.vb
	deleted:    DWSIM.Math/packages.config
	modified:   dwsimLibs.vbproj


