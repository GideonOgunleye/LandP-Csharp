Feature: VisitLandingPage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@SmokeTest
Scenario: Insert Visit Mosiac Tile of 4
	Given User is On CMS Login Page 'http://qa.cms.londonandpartners.com/sitecore/login'
	When User Enters Valid Credebtials
	| Username | Password |
	| QA_User   | Test1234  |
	And Clicks Login Button
	Then Sitecore Experience Platform Page Should Be Displayed
	When User Clicks on Content Editor Tab
	Then Content Editor Page Should Be Displayed
	When Product is Checked In
	Then I Should Be Able To Preview Visit Landing Page 'http://qa.cms.londonandpartners.com/?sc_mode=edit&sc_itemid=%7b7868EA52-BEB8-4600-A1F5-6F8C6C3B6571%7d&sc_version=10&sc_lang=en&sc_site=Visit_CA'
	When I Click on Toggle Ribbon
	Then I Should Be Able To Edit The Page
	And Insert Component on Page
	Then User is Able To Log Out
	
