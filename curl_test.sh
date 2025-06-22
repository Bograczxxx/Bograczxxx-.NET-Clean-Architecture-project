#!/bin/bash

TOKEN=$(curl -s -X POST "http://localhost:5000/api/Auth/login?username=admin" | jq -r .token)

echo "Token: $TOKEN"

curl -H "Authorization: Bearer $TOKEN" -H "X-Requested-With: curl" -X POST http://localhost:5000/api/Authors -H "Content-Type: application/json" -d '{"name":"Test Author"}'

curl -H "X-Requested-With: curl" http://localhost:5000/api/Authors
