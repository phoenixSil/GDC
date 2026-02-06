# SiteEglise (WordPress)

Ce dossier contient une base WordPress prête à démarrer avec Docker Compose.

## Démarrage rapide

1. Copier les variables d'environnement :
   ```bash
   cp .env.example .env
   ```
2. Démarrer WordPress et MySQL :
   ```bash
   docker compose up -d
   ```
3. Ouvrir le site :
   - http://localhost:8080

## Services

- `wordpress` : site WordPress
- `db` : base MySQL 8

## Sortir complètement de Gdc (repo séparé)

J'ai ajouté un script pour préparer un dépôt Git indépendant `SIteEglise` en dehors de ce monorepo.

```bash
bash scripts/init-standalone-repo.sh
```

Par défaut, il crée le dépôt local dans :
- `/workspace/SIteEglise`

Tu peux aussi personnaliser le chemin et le nom du repo :

```bash
bash scripts/init-standalone-repo.sh /workspace/SIteEglise SIteEglise
```

Ensuite, pousse vers ton GitHub :

```bash
cd /workspace/SIteEglise
git branch -M main
git remote add origin git@github.com:<TON_USER>/SIteEglise.git
git push -u origin main
```

> Remarque: la création automatique du repo GitHub distant n'est pas possible ici (pas de `gh` CLI ni token configuré).
