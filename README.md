# BEPUphysicsBug


1) Clone project


2) Run BEPUphysicsDemos.sln


3) Try to do same things, when you directly in front of wall(when you enter a hole in wall, don't press "Z" key)
(https://www.youtube.com/watch?v=PsRMv2ihFV0)

4) This bug appears when hole's height is 1m and agent's height more than 2m, for example, 3m or 5m.




#List of changed files:


1)BEPUphysicsDemos\Alternate Movement\CharacterControllerInput (virtual functions)


2)BEPUphysicsDemos\Alternate Movement\BugShowerCharacterController (an character controller which produces bug)


3)C:\workspace\BEPUPhysicsBug\BEPUphysicsDemos\Demos\BugDemo\FullSceneBugDemo 


4)C:\workspace\BEPUPhysicsBug\BEPUphysicsDemos\Demos\BugDemo\PrimitiveSceneBugDemo 


3th and 4th classes are playground with scene that produces bug. (Use "1" and "2" on keyboard to switch them)


