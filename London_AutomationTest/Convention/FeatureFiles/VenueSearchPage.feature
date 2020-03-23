Feature: VenueSearchPage
	In order to test a deploy
	As a visitor
	I want to check the venue search page is up and running:

	
#@Smoke
Scenario: Validate Search Page is Up
	Given I Navigate To The Search Venue Page '/search-venue'
	Then I Should See Venue Search Results

#@Smoke
Scenario: Validate Search Page Home Link
	
