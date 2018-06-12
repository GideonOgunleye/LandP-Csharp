Feature: Sitecore Login
	As a CMS User
	I Want To Be Able to Login To The Content Editor CMS
	So That I Can Create And Edit Content

#@mytag
Scenario: Login With Valid Credentials
	Given User is On CMS Login Page 'http://qa.cms.londonandpartners.com/sitecore/login'
	When User Enters Valid Credebtials
	| Username | Password |
	| gogunleye   | z  |
	And Clicks Login Button
	Then Sitecore Experience Platform Page Should Be Displayed
	When User Clicks on Content Editor Tab
	Then Content Editor Page Should Be Displayed

Scenario: Login WIth Invalid Credentials
	Given User is On CMS Login Page "http://qa.cms.londonandpartners.com/sitecore/login"
	When User Enters InValid Credebtials
	| Username | Password |
	| Valid    | InValid  |
	And Clicks Login Button
	Then User Should See Invalid Login Message "" on Screen
