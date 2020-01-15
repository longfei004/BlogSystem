import React from 'react';
import { Link } from 'react-router-dom';
import './BlogTable.less';

const BlogTable = ({ blogs }) => {

    const blogList = blogs.map(blog => {
        return (
            <tr key={'blogTable' + blog.id}>
                <td>{blog.title}</td>
                <td>已发布</td>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    <Link to={`/blogs/edit/${blog.id}`}><span>编辑</span></Link>
                </td>
            </tr>
        )
    })

    return (
        <div className='blog-table'>
            <table>
                <tr>
                    <th>标题</th><th>状态</th><th>分类</th><th>标签</th><th>发布时间</th><th>操作</th>
                </tr>
                {blogList}
            </table>
        </div>
    )
}

export default BlogTable;