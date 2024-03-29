# motorport-core-api

## API Documentation

https://motorport-core-api.azurewebsites.net/swagger/index.html

### API Base URL

https://motorport-core-api.azurewebsites.net/api/v1/

### Git Flow

#### Features
```
  feature-[FEATURE_NAME]-[#PIVOTAL-USER-STORY-ID]
```
Every new feature that would be implemented should have its own branch

For example: feature-crudUsers-#123456

#### Bugs
```
fix-[BUG_REPORTED]-(OPTIONAL)[#PIVOTAL-USER-STORY-ID]
```
If we reported bugs in develop, create a specific branch to fix it.

For example: fix-createTask-#123456

#### Config
```
config-[CONFIG_SETUP]-(OPTIONAL)[#PIVOTAL-USER-STORY-ID]
```
If some dependencies file have to be edited, not for problems just for a safe update, create a branch.

For example: config-mavenDependenciesUpdate-#123456

After the work in your branch is finished, PR to develop branch.
