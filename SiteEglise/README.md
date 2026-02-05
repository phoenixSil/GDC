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

## Important

Je ne peux pas créer directement un nouveau dépôt GitHub depuis cet environnement car il n'y a ni `gh` CLI ni token GitHub configuré.

Pour créer le dépôt `SIteEglise` dans ton GitHub puis y pousser ce dossier :

```bash
# Depuis la racine de ce repo
cd SiteEglise
git init
git add .
git commit -m "feat: initialiser un site WordPress avec docker compose"
git branch -M main
git remote add origin git@github.com:<TON_USER>/SIteEglise.git
git push -u origin main
```
