Feature: LnP_TourismPartnerspage
	In order to Ensure Successful Deploys
	As a Quality Assurance Analyst
	I want to Validate all page components
	Are Working as Intended

@SmokeTest
Scenario: LnP TourismPage Breadcrumb
	Given I Am On The Tourism Partners Page
	Then I Should See Home On Breadcrumb Link
	And I Should Also See Partners On Breadcrumb Link

@SmokeTest
Scenario: LnP TourismPage Quotes Component
	Given  I Am On The Tourism Partners Page
	Then I Should See Text In Quotes Component

@SmokeTest
Scenario: LnP TourismPage Row of 4 Component
	Given I Am On The Tourism Partners Page
	Then I Should See Images In Row of 4 Component

@SmokeTest
Scenario: LnP TourismPage GeneralWrapper CTA Component
	Given I Am On The Tourism Partners Page
	Then I Should See Text In CTA Component
	When I Click On Become A Partner Link
	Then I Should Be Navigated To 