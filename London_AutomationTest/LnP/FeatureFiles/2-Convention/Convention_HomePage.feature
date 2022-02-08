Feature: Convention_HomePage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Qa-Smoke
Scenario: Convention Home Page Is Up
	Given I Navigate To The Home Page ''
	Then I Should Be Shown The Main Title 'Welcome to Lagos'
