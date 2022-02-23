Feature: Sitecore CMS
	As a CMS User
	I Want To Be Able to Login To The Content Editor CMS
	So That I Can Create And Edit Content

#@Qa-Smoke
Scenario: Login With Valid Credentials
	Given User is On CMS Login Page 'http://qa.cms.londonandpartners.com/sitecore/login'
	When User Enters Valid Credebtials
	| Username | Password |
	| QA_User   | Test1234  |
	And Clicks Login Button
	Then Sitecore Experience Platform Page Should Be Displayed
	When User Clicks on Content Editor Tab
	Then Content Editor Page Should Be Displayed

@SanityTest
Scenario: Edit Visit Venue Product
	Given User is On CMS Login Page 'http://qa.cms.londonandpartners.com/sitecore/login'
	When User Enters Valid Credebtials
	| Username | Password |
	| QA_User   | Test1234  |
	And Clicks Login Button
	Then Sitecore Experience Platform Page Should Be Displayed
	When User Clicks on Content Editor Tab
	Then Content Editor Page Should Be Displayed
	When User Searches For Event '27016170'
	Then User Should Be Able To Lock and Edit Venue
	And User Should Be Able To Publish Event
	#When User Navigates to Venue CMS Url 'http://qa.cms.londonandpartners.com/?sc_mode=edit&sc_itemid=%7b41A042FA-1633-49FA-BB04-C0831883AF6F%7d&sc_version=2&sc_lang=en&sc_site=Visit_CA'
	
