Feature: KeywordSearch
	As a Automation Bot
	I want to use the search function
	So that Required Products/Events Returned

@Smoke
Scenario: The Natural History Museum Keyword Search
	Given User is on Home Page 'http://qa.visitlondon.com'
	When I Enter 'Natural History Museum' Keyword
	And I Hit The Search Button
	Then I Should See Search Results for 'Natural Museum' Containing The Keyword 'Natural'

@Smoke
Scenario: The Science Museum Keyword Search
	Given User is on Home Page 'http://qa.visitlondon.com'
	When I Enter 'Science Museum' Keyword
	And I Hit The Search Button
	Then I Should See Search Results for 'Science Museum' Containing The Keyword 'Science'

@Smoke
Scenario: The Premier Inn Keyword Search
	Given User is on Home Page 'http://qa.visitlondon.com'
	When I Enter 'Premier Inn' Keyword
	And I Hit The Search Button
	Then I Should See Search Results for 'Premier Inn' Containing The Keyword 'Premier'

@Smoke
Scenario: The Holiday Inn Keyword Search
	Given User is on Home Page 'http://qa.visitlondon.com'
	When I Enter 'Holiday Inn' Keyword
	And I Hit The Search Button
	Then I Should See Search Results for 'Holiday Inn' Containing The Keyword 'Holiday'

@Smoke
Scenario: The Harry Potter Keyword Search
	Given User is on Home Page 'http://qa.visitlondon.com'
	When I Enter 'Harry Potter' Keyword
	And I Hit The Search Button
	Then I Should See Search Results for 'Harry Potter' Containing The Keyword 'Harry'