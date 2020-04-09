Feature: ConventionVenueSearchPage
	In order to test a deploy
	As a visitor
	I want to check the venue search page is up and running:

	
@Smoke
Scenario: Convention Search Page is Up
	Given I Navigate To The Search Venue Page '/search-venue'
	Then I Should See Venue Search Results

@Smoke
Scenario: Validate Convention Search Page Home Link
	Given I Navigate To The Search Venue Page '/search-venue'
	Then I should See the Home Link in BreadCrumb
	When I Click on The Home Page Link
	Then I Should Be Navigated To The Home Page

@Smoke
Scenario: Validate Convention Search Page BreadCrumb
	Given I Navigate To The Search Venue Page '/search-venue'
	Then I Should See The Full BreadCrumb Link
