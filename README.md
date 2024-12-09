# Local Development Database

Local development environment setup for Aurora PostgreSQL-compatible database.

## Prerequisites

- Docker (20.10.0+)
- Docker Compose (v2.0.0+)
- Minimum 2GB available memory
- Minimum 1GB free disk space

## Quick Start

## 1. Set up environment variables

```bash
cd .docker/local
cp .env.example .env
```

## 2. Configure environment variables in .env if needed

### Default port is 5432

```bash
DB_PORT=5432        # Change if needed
DB_USER=dev_user    # Default user
DB_PASSWORD=dev_password
DB_NAME=dev_db
```

## 3. Start the database

```bash
docker-compose up -d
```

## 4. Verify the service

```bash
docker-compose ps
```

## Connection Details

```bash
Default configuration:
Host: localhost
Port: 5432 (customizable via DB_PORT in .env)
Database: dev_db
Username: dev_user
Password: dev_password
```

## Connection string format

```bash
postgresql://dev_user:dev_password@localhost:5432/dev_db
```

## Common Operations

### Start services

```bash
docker-compose up -d
```

### Stop services

```bash
docker-compose down
```

## Troubleshooting

### Connection Issues

```bash

#Check service status
docker-compose ps
Review logs
docker-compose logs postgres
```

### Schema Initialization

```bash

#If initialization scripts haven't run:
docker-compose down -v
docker-compose up -d
```
