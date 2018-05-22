Feature: AreaBrowsePage
	In order to test a deploy
	As a visitor
	I want to check the an area browser page is up and running:

@Tag1
Scenario: Area Browse page is up
	#Given I navigate to the Area Browser page '/area/london-bridge'
	Given I navigate to the Area Browser page '/area/london-bridge'
	And I don't see an error code
	Then I should be shown the area browse search grid
