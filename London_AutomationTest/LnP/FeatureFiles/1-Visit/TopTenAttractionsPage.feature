Feature: TopTenAttractionsPage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

#@Qa-Smoke
Scenario: Top Ten Bookable Attractions Is Up
	Given I Navigate to the top ten attractions page '/things-to-do/sightseeing/london-attraction/top-ten-attractions'
	And The Tab List is Present on Page
	When When I Click On Top Ten Bookable Attractions Tab
	Then Then I Should See an attraction Item

#@Qa-Smoke
Scenario: Top Ten Free Attractions Is Up
	Given I Navigate to the top ten attractions page '/things-to-do/sightseeing/london-attraction/top-ten-attractions'
	And The Tab List is Present on Page
	When When I Click On Top Ten Free Attractions Tab
	Then Then I Should See an attraction Item
