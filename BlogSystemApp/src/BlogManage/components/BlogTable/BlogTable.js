import React from 'react';
import { Link } from 'react-router-dom';
import './BlogTable.less';

const BlogTable = ({ blogs, handleOnDelete }) => {

    const blogList = blogs.map(blog => {
        return (
            <tr key={'blogTable' + blog.id}>
                <td className='table-title'><Link to={`/blogs/${blog.id}`}>{blog.title}</Link></td>
                <td>已发布</td>
                <td></td>
                <td></td>
                <td></td>
                <td className='table-action'>
                    <Link to={`/blogs/edit/${blog.id}`}><span>编辑</span></Link>
                    <span>|</span>
                    <a><span className='table-delete' onClick={() => handleOnDelete(blog.id)}>删除</span></a>
                </td>
            </tr>
        )
    })

    return (
        <div className='blog-table'>
            <table>
                <thead>
                    <tr>
                        <th>标题</th><th>状态</th><th>分类</th><th>标签</th><th>发布时间</th><th>操作</th>
                    </tr>
                </thead>
                <tbody>{blogList}</tbody>
            </table>
        </div>
    )
}

export default BlogTable;