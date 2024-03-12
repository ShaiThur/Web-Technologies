import React from 'react';
import { faStar } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

const Post = (props) => {
    const stars = []
    for (let i = 0; i < props.post.countStars; i++)
        stars.push([<FontAwesomeIcon icon={faStar} className="starIcon"/>])

    return (
        <>
            <div className='post'>
                <div className='postContent'>
                    <strong>{props.post.title}</strong>
                    <div>
                        Срок сдачи: {props.post.deadLine}
                    </div>

                </div>
                <div className='postHelper'>
                    <div className='difficulty'>
                        {stars}
                    </div>
                    <button>Взять</button>
                </div>
            </div>
        </>
    );
};

export default Post;