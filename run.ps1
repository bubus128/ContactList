param(
    [string]$Mode
)

if ($Mode -eq "--DbOnly") {
    Write-Host "Starting database only..."
    docker compose -f src/compose.db.yaml up -d
}
else {
    Write-Host "Starting API + database..."
    docker compose -f src/compose.yaml up -d
}