Feature: Sitecore Login
	As a CMS User
	I Want To Be Able to Login To The Content Editor CMS
	So That I Can Create And Edit Content

@Smoke
Scenario: Login With Valid Credentials
	Given User is On CMS Login Page 'http://qa.cms.londonandpartners.com/sitecore/login'
	When User Enters Valid Credebtials
	| Username | Password |
	| gogunley   | P@rtner$L0nd0n  |
	And Clicks Login Button
	Then Sitecore Experience Platform Page Should Be Displayed
	When User Clicks on Content Editor Tab
	Then Content Editor Page Should Be Displayed


