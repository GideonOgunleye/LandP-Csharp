Feature: LnP_Homepage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@SmokeTest
Scenario: LnP Homepage Is Up
	When I Navigate To LnP Homepage
	Then I Should See The Main Title ''
