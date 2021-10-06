Feature: Business_HomePage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@SmokeTest
Scenario: BusinessHomePageIsUp
	Given I Am On Business Landing Page
	Then the Should See 'Welcome to London' Page Title 
