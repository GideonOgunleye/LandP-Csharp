﻿Feature: Redirects
	As An Automation Bot
	I Want To Be Able to enter redirect Urls
	So That I Can navigate to required Destination Pages

@Smoke
Scenario: Validate Whats On Page Redirects
	Given User Enters Url 'http://qa.visitlondon.com/heart'
	Then User should be navigated to the "Whats On" Page and See Text "What's on in London" On Page
	

@Smoke
Scenario: Validate About Us Page Redirects
	Given User Enters Url 'http://qa.visitlondon.com/about-us/about-visitlondoncom'
	Then User should be navigated to the "About Us" Page and See Text "About visitlondon.com" On Page