Feature: ConventionVenueSearchPage
	In order to test a deploy
	As a visitor
	I want to check the venue search page is up and running:

	
@Qa-Smoke
Scenario: Convention Search Page is Up
	Given I Navigate To The Search Venue Page '/search-venue'
	Then I Should See Venue Search Results

#@Smoke
Scenario: Convention Search Page Home Link
	Given I Navigate To The Search Venue Page '/search-venue'
	Then I should See the Home Link in BreadCrumb
	When I Click on The Home Page Link
	Then I Should Be Navigated To The Home Page

@Qa-Smoke
Scenario: Convention Search Page BreadCrumb
	Given I Navigate To The Search Venue Page '/search-venue'
	Then I Should See The Full BreadCrumb Link


@Qa-Smoke
Scenario: Convention Search Page Results
	Given I Navigate To The Search Venue Page '/Search-venue'
	When I Enter '1000' in Min Field
	And I Enter '30000' in Max Field
	When I Click Search Button
	Then i Should See 'Barbican Centre' and 'ExCeL London' in Search Reuslt

@SmokeTest
Scenario: Convention Search Page Pagination
	Given I Navigate To The Search Venue Page '/Search-venue'
	When I Click on Next Pagination Button
	Then I Should See 'Text' in Search Results


