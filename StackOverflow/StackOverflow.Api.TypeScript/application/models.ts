export class ApiBadgeRequestModel {
				date:string;
id:number;
name:string;
userId:number;

	
				constructor() {
					this.date = '';
this.id = 0;
this.name = '';
this.userId = 0;

		
				}
			}

			export class ApiBadgeResponseModel {
				date:string;
id:number;
name:string;
userId:number;

	
				constructor() {
					this.date = '';
this.id = 0;
this.name = '';
this.userId = 0;

		
				}
			}
			export class ApiCommentRequestModel {
				creationDate:string;
id:number;
postId:number;
score:number;
text:string;
userId:number;

	
				constructor() {
					this.creationDate = '';
this.id = 0;
this.postId = 0;
this.score = 0;
this.text = '';
this.userId = 0;

		
				}
			}

			export class ApiCommentResponseModel {
				creationDate:string;
id:number;
postId:number;
score:number;
text:string;
userId:number;

	
				constructor() {
					this.creationDate = '';
this.id = 0;
this.postId = 0;
this.score = 0;
this.text = '';
this.userId = 0;

		
				}
			}
			export class ApiLinkTypeRequestModel {
				id:number;
type:string;

	
				constructor() {
					this.id = 0;
this.type = '';

		
				}
			}

			export class ApiLinkTypeResponseModel {
				id:number;
type:string;

	
				constructor() {
					this.id = 0;
this.type = '';

		
				}
			}
			export class ApiPostHistoryRequestModel {
				comment:string;
creationDate:string;
id:number;
postHistoryTypeId:number;
postId:number;
revisionGUID:string;
text:string;
userDisplayName:string;
userId:number;

	
				constructor() {
					this.comment = '';
this.creationDate = '';
this.id = 0;
this.postHistoryTypeId = 0;
this.postId = 0;
this.revisionGUID = '';
this.text = '';
this.userDisplayName = '';
this.userId = 0;

		
				}
			}

			export class ApiPostHistoryResponseModel {
				comment:string;
creationDate:string;
id:number;
postHistoryTypeId:number;
postId:number;
revisionGUID:string;
text:string;
userDisplayName:string;
userId:number;

	
				constructor() {
					this.comment = '';
this.creationDate = '';
this.id = 0;
this.postHistoryTypeId = 0;
this.postId = 0;
this.revisionGUID = '';
this.text = '';
this.userDisplayName = '';
this.userId = 0;

		
				}
			}
			export class ApiPostHistoryTypeRequestModel {
				id:number;
type:string;

	
				constructor() {
					this.id = 0;
this.type = '';

		
				}
			}

			export class ApiPostHistoryTypeResponseModel {
				id:number;
type:string;

	
				constructor() {
					this.id = 0;
this.type = '';

		
				}
			}
			export class ApiPostLinkRequestModel {
				creationDate:string;
id:number;
linkTypeId:number;
postId:number;
relatedPostId:number;

	
				constructor() {
					this.creationDate = '';
this.id = 0;
this.linkTypeId = 0;
this.postId = 0;
this.relatedPostId = 0;

		
				}
			}

			export class ApiPostLinkResponseModel {
				creationDate:string;
id:number;
linkTypeId:number;
postId:number;
relatedPostId:number;

	
				constructor() {
					this.creationDate = '';
this.id = 0;
this.linkTypeId = 0;
this.postId = 0;
this.relatedPostId = 0;

		
				}
			}
			export class ApiPostRequestModel {
				acceptedAnswerId:number;
answerCount:number;
body:string;
closedDate:string;
commentCount:number;
communityOwnedDate:string;
creationDate:string;
favoriteCount:number;
id:number;
lastActivityDate:string;
lastEditDate:string;
lastEditorDisplayName:string;
lastEditorUserId:number;
ownerUserId:number;
parentId:number;
postTypeId:number;
score:number;
tag:string;
title:string;
viewCount:number;

	
				constructor() {
					this.acceptedAnswerId = 0;
this.answerCount = 0;
this.body = '';
this.closedDate = '';
this.commentCount = 0;
this.communityOwnedDate = '';
this.creationDate = '';
this.favoriteCount = 0;
this.id = 0;
this.lastActivityDate = '';
this.lastEditDate = '';
this.lastEditorDisplayName = '';
this.lastEditorUserId = 0;
this.ownerUserId = 0;
this.parentId = 0;
this.postTypeId = 0;
this.score = 0;
this.tag = '';
this.title = '';
this.viewCount = 0;

		
				}
			}

			export class ApiPostResponseModel {
				acceptedAnswerId:number;
answerCount:number;
body:string;
closedDate:string;
commentCount:number;
communityOwnedDate:string;
creationDate:string;
favoriteCount:number;
id:number;
lastActivityDate:string;
lastEditDate:string;
lastEditorDisplayName:string;
lastEditorUserId:number;
ownerUserId:number;
parentId:number;
postTypeId:number;
score:number;
tag:string;
title:string;
viewCount:number;

	
				constructor() {
					this.acceptedAnswerId = 0;
this.answerCount = 0;
this.body = '';
this.closedDate = '';
this.commentCount = 0;
this.communityOwnedDate = '';
this.creationDate = '';
this.favoriteCount = 0;
this.id = 0;
this.lastActivityDate = '';
this.lastEditDate = '';
this.lastEditorDisplayName = '';
this.lastEditorUserId = 0;
this.ownerUserId = 0;
this.parentId = 0;
this.postTypeId = 0;
this.score = 0;
this.tag = '';
this.title = '';
this.viewCount = 0;

		
				}
			}
			export class ApiPostTypeRequestModel {
				id:number;
type:string;

	
				constructor() {
					this.id = 0;
this.type = '';

		
				}
			}

			export class ApiPostTypeResponseModel {
				id:number;
type:string;

	
				constructor() {
					this.id = 0;
this.type = '';

		
				}
			}
			export class ApiTagRequestModel {
				count:number;
excerptPostId:number;
id:number;
tagName:string;
wikiPostId:number;

	
				constructor() {
					this.count = 0;
this.excerptPostId = 0;
this.id = 0;
this.tagName = '';
this.wikiPostId = 0;

		
				}
			}

			export class ApiTagResponseModel {
				count:number;
excerptPostId:number;
id:number;
tagName:string;
wikiPostId:number;

	
				constructor() {
					this.count = 0;
this.excerptPostId = 0;
this.id = 0;
this.tagName = '';
this.wikiPostId = 0;

		
				}
			}
			export class ApiUserRequestModel {
				aboutMe:string;
accountId:number;
age:number;
creationDate:string;
displayName:string;
downVote:number;
emailHash:string;
id:number;
lastAccessDate:string;
location:string;
reputation:number;
upVote:number;
view:number;
websiteUrl:string;

	
				constructor() {
					this.aboutMe = '';
this.accountId = 0;
this.age = 0;
this.creationDate = '';
this.displayName = '';
this.downVote = 0;
this.emailHash = '';
this.id = 0;
this.lastAccessDate = '';
this.location = '';
this.reputation = 0;
this.upVote = 0;
this.view = 0;
this.websiteUrl = '';

		
				}
			}

			export class ApiUserResponseModel {
				aboutMe:string;
accountId:number;
age:number;
creationDate:string;
displayName:string;
downVote:number;
emailHash:string;
id:number;
lastAccessDate:string;
location:string;
reputation:number;
upVote:number;
view:number;
websiteUrl:string;

	
				constructor() {
					this.aboutMe = '';
this.accountId = 0;
this.age = 0;
this.creationDate = '';
this.displayName = '';
this.downVote = 0;
this.emailHash = '';
this.id = 0;
this.lastAccessDate = '';
this.location = '';
this.reputation = 0;
this.upVote = 0;
this.view = 0;
this.websiteUrl = '';

		
				}
			}
			export class ApiVoteRequestModel {
				bountyAmount:number;
creationDate:string;
id:number;
postId:number;
userId:number;
voteTypeId:number;

	
				constructor() {
					this.bountyAmount = 0;
this.creationDate = '';
this.id = 0;
this.postId = 0;
this.userId = 0;
this.voteTypeId = 0;

		
				}
			}

			export class ApiVoteResponseModel {
				bountyAmount:number;
creationDate:string;
id:number;
postId:number;
userId:number;
voteTypeId:number;

	
				constructor() {
					this.bountyAmount = 0;
this.creationDate = '';
this.id = 0;
this.postId = 0;
this.userId = 0;
this.voteTypeId = 0;

		
				}
			}
			export class ApiVoteTypeRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiVoteTypeResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}