#!/bin/bash

if [ -n "$BACKUP_FILE" ] && [ -f "/docker-entrypoint-initdb.d/$BACKUP_FILE" ]; then
  echo "Restoring database from $BACKUP_FILE"
  pg_restore -U "$POSTGRES_USER" -d "$POSTGRES_DB" "/docker-entrypoint-initdb.d/$BACKUP_FILE"
  echo "Database $POSTGRES_DB restored successfully"
else
  echo "Backup file $BACKUP_FILE not found, skipping restore."
fi
