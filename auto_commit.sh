#!/bin/bash

# Get today's date in YYYY-MM-DD format
TODAY=$(date +"%a,%d %b, %Y %I:%M %p")

# add all changes
git add *
# commit changes
git commit -m "🤖 Updated projects till $TODAY"
git push origin master