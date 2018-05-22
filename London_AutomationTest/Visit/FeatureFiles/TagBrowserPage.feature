Feature: TagBrowserPage
	In order to test a deploy
	As a visitor
	I want to check the an tag browser page is up and running:

#@mytag
Scenario: Tag Browse page is up
	Given I navigate to the Tag Browser page '/tag/christmas-lights'
	And I don't see an error code
	Then I should be shown the tag browse search grid
