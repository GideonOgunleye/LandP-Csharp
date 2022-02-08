Feature: Convention_SearchServicesPage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Qa-Smoke
Scenario: Convention Search Services Is Up
	Given I Navigate To Search Services Page'/search-services'
	#Then I Should See Search Services Page Results
	Then I Should See 'Qa' Search Services Page Results

@Preview-Smoke
Scenario: Convention Preview Search Services Page Is Up
	Given I Navigate To Preview Search Services Page '/search-services'
	Then I Should See 'Preview' Search Services Page Results
