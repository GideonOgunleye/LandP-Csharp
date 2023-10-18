Feature: Business_HomePage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Qa-Smoke
Scenario: BusinessHomePageIsUp
	Given I Am On Business Landing Page
	Then the Should See 'Grow your business in London' Page Title 

@Qa-DailyStart
Scenario: QaBusinessHomePageIsUp
	Given I Am On Business Landing Page
	Then the Should See 'Welcome to London' Page Title 

@SmokeTest
Scenario: BusinessHomePageFeatureCallOut
	Given I Am On Business Landing Page
	Then I Should See Feature Call Out Component