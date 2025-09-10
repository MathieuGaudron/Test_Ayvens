#!/usr/bin/env bash
set -euo pipefail

# 1) Manifest d’outils local (si absent)
[ -f .config/dotnet-tools.json ] || dotnet new tool-manifest

# 2) Installer la CLI Swagger (si pas déjà installée)
dotnet tool install Swashbuckle.AspNetCore.Cli --version 6.* || true

# 3) Trouver le projet .csproj (ex: ./test_voitures/test_voitures.csproj)
CSPROJ=$(find . -name "*.csproj" | head -n1)
if [ -z "${CSPROJ:-}" ]; then
  echo "Aucun fichier .csproj trouvé. Lance le script depuis la racine du repo."
  exit 1
fi

# 4) Build du projet
dotnet build "$CSPROJ" -c Debug

# 5) Fabriquer le chemin vers la DLL
PROJDIR=$(dirname "$CSPROJ")
PROJNAME=$(basename "$CSPROJ" .csproj)
DLL="$PROJDIR/bin/Debug/net8.0/$PROJNAME.dll"

if [ ! -f "$DLL" ]; then
  echo "DLL introuvable : $DLL"
  exit 1
fi

# 6) Générer le fichier OpenAPI (docName = v1)
dotnet swagger tofile --output openapi.json "$DLL" v1

echo "OpenAPI généré"
