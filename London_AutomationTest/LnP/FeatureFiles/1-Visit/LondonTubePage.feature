Feature: LondonTubePage
	In order to test a deploy
	As a visitor
	I want to check the London tube page is up and running:

@Qa-Smoke
Scenario: LondonTubePageIsUp
	Given I navigate to the London tube page  '/traveller-information/getting-around-london/london-tube'
	#And I don't see an error code
	Then I should be shown the  'London Underground' Title

@Preview-Smoke
Scenario: Preview LondonTubePageIsUp
	Given I navigate to the Preview London tube page  '/traveller-information/getting-around-london/london-tube'
	#And I don't see an error code
	Then I should be shown the  'London Underground' Title
